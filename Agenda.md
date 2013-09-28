# Take-off med RavenDB

Hvad er det her NoSQL? ...NotSQL vs. No-Only-SQL?

### CAP-theorem

* Consistency
* Availability
* Partition tollerance

### Databasetyper

* Graph
* Key/Value
* Document

### Hvordan ser Ravnen ud?

* Schema-free
* Fast-reads
* Automagic
* Deployment-muligheder
* Safe-by-default
	* Det er svært at gøre noget "dumt"
		* Limit på antal reads
		* Limit på mængden af data (128/1024)
	* Transactional

### Men hvordan flyver Ravnen så?

* Documenter
	* POCO / JSON
* Collections
* Identifiers
	* string (resource)
	* int, Guid...mv.
* LINQ

### Man skal lette før man kan flyve

##### Hosts

* Debug console
* Windows Service
* IIS
* Embedded
* Cloud

##### Storage
* InMemory
	* Unittest
	* Cache
* Disk

### Så vis da noget kode!

* Connecting
	* DocumentStore
	* DocumentSession
* CRUD
	* Defer -> DeleteCommandData
* Query
	* Eventual consistency
		* IndexStore...eventually
		* DocumentStore...immediately (eg. Load)
	* Strings...you wish

#### Indexes

* Lucene
* Non-indexed
	* Temp Index
	* Auto Index
* Map / Reduce
	* Simple
	* Multi-map
* Transformations
* Aging
* Maintainance

#### Bundles

### Management

* Backup / Restore
* Lock Index