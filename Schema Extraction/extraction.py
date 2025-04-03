import requests
from bs4 import BeautifulSoup
import json

def parse_sysml2_doc(url):
    # Realizar la solicitud GET a la URL
    response = requests.get(url)
    if response.status_code != 200:
        print(f"Error: No se pudo acceder a la URL (status code {response.status_code})")
        return
    
    # Parsear el contenido HTML
    soup = BeautifulSoup(response.content, 'html.parser')

    # Encontrar todos los encabezados h3
    h3_headers = soup.find_all("h3")

    if not h3_headers:
        print("No se encontraron encabezados <h3>.")
        return
    enums = {}
    classes = {}
    card_1 = {}
    for i, header in enumerate(h3_headers):
        # Imprimir el encabezado actual
        
        # Buscar el siguiente hermano después del <h3> para identificar tablas
        next_sibling = header.find_next_sibling()
        table_count = 0
        
        if "Kind" in header.text.strip():
            enums[header.text.strip()]=[]
            while next_sibling:
                # Si encontramos un nuevo <h3>, detenemos la búsqueda de tablas
                if next_sibling.name == "h3":
                    break
                
                # Si encontramos una tabla, la procesamos
                if next_sibling.name == "table":
                    table_count += 1
                    rows = next_sibling.find_all("tr")
                    for row in rows:
                        cells = row.find_all(["th", "td"])
                        cell_data = [cell.text.strip() for cell in cells]
                        
                        if "Name" not in cell_data:
                            enums[header.text.strip()].append(cell_data[0])
                
                # Continuar al siguiente hermano
                next_sibling = next_sibling.find_next_sibling()
            
            if table_count == 0:
                print("No se encontraron tablas debajo de este encabezado.")
        
        elif "Release" in header.text.strip() or "Classes" in header.text.strip() or "EnumerationTypes" in header.text.strip():
            pass

        else:
            classes[header.text.strip()]={}
            card_1[header.text.strip()]={}
            while next_sibling:
                if next_sibling.name == "h3":
                    break
                if next_sibling.name == "table" and table_count>0:
                    table_count += 1
                    rows = next_sibling.find_all("tr")
                    for row in rows:
                        cells = row.find_all(["th", "td"])
                        cell_data = [cell.text.strip() for cell in cells]
                        
                        if "Name" not in cell_data:
                            attribute = cell_data[0]
                            attr_type = cell_data[1].split(" ")[0]

                            
                            try:
                                cardinality = cell_data[1].split(" ")[1]
                                card = cardinality[1]
                                data = attr_type + "?" + card 
                                classes[header.text.strip()][attribute] = data
                                if card == "1":
                                    card_1[header.text.strip()][attribute] = attr_type

                            except:
                                pass
                

                elif next_sibling.name == "table" and table_count==0:
                    table_count += 1

                next_sibling = next_sibling.find_next_sibling()
        

        
                


    with open("enums.json", "w") as file1:
        json.dump(enums, file1, indent=4)

    with open("classes.json", "w") as file2:
        json.dump(classes, file2, indent=4)

    print(card_1)
    with open("card_1.json", "w") as file3:
        json.dump(card_1, file3, indent=4)

# URL a parsear
url = "https://modeldocs.sysml2.net/#ViewUsage"
parse_sysml2_doc(url)
