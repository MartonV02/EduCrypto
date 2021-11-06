 # DataStructure #

 ## User ##
Users handling:
- id (primary key)
- user name
- password
- email
- full name
- birth date
- xp level [int]

User finance:
- userId (foreign key, primary key)
- wallet number [string]
- money ($) [float]

Users Crypto:
- id (primary key)
- wallet number (foreign key)
- crypto type [string]
- crypto value [float]

Users Trade Historys:
- id (primary key)
- userId (foreign key)
- trade date
- spent type 
- spent value
- bought type
- bougth value
- groupId

 ## Group ##
Groups:
- id
- name
- start budget

Users handling for groups:
- id (primary key)
- userId
- groupId (foreign key)
- access level [string]
- group wallet number
- money ($)

## Exchange rate ##
Kripto árfolyam tárolás:
- Third party data
