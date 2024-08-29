# **Metrans .Net developer assignment**
Your task is to design and implement a simple application in .NET that will process EDI messages in XML format.

The application will include receiving and validating XML messages and designing a database model to store this data.
 
# **Requirements**

1. Receipt and validation of EDI messages:

* Implement a method that accepts an EDI message in XML format.
* Validate the XML message against a simple XSD schema that contains the basic structure of the order (eg order ID, date, list of products).
* Write the data into the database objects (see point 2).

2. Database model design:
   
* Based on the structure of the XML message, design a database model for storing data from the EDI message.
* The model should include the design of at least one main table (e.g. orders) and one or more secondary tables (e.g. order items).
* Describe the relationships between the tables.

# My Solution
 
Console app that reads an EDI message in XML format from *order.xml* file and for validation uses XSD schema in *order.xsd* file. 

The successfully validated message is stored in the MS SQL Database, which has two tables. *Orders* table stores order and *Items* table stores order items. The relationship between these tables is one-to-many.
