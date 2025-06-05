# ^\.text:[0-9A-F]+\s+cmp\s+\[rsp[^\]]+?\],\s*([0-9A-F]{4})h
#parse the regex above from the file proto_lounge.txt and get all the 1st group matches

import re
def parse_proto_lounge(file_path):
    with open(file_path, 'r') as file:
        content = file.read()
    
    pattern = r'\.text:[0-9A-F]+\s+cmp\s+\[rsp[^\]]+?\],\s*([0-9A-F]{4})h'
    matches = re.findall(pattern, content)
    
    return matches

file_path = 'proto_parse.txt'
matches = parse_proto_lounge(file_path)

# dedupe
matches = list(set(matches))
for match in matches:
    print(match)

print(f"Total matches found: {len(matches)}")