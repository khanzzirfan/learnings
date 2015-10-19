/***** 1. Pre Checks ***************/
1. Copy Mongodb.exe installation file to c:\mongodb

/***** 2. Run installation ***************/
1. Open Command Prompt and run as administrator.
2. Run below command 
	c:\mongodb\msiexec.exe /q /i mongodb-win32-x86_64-2008plus-ssl-3.0.7-signed.msi INSTALLLOCATION="C:\mongodb" ADDLOCAL="all"
	
/***** 3. Set up the MongoDB environment***************/	
1. Create Directories
	a. c:\mongodb\test
	b. c:\mongodb\test\mongodb #this is basically a server.
	c. c:\mongodb\test\mongodb\data
2. C:\mongodb\bin\mongod.exe --dbpath c:mongodb\test\mongodb\data

/***** 4. Start MongoDB.***************/	
	C:\mongodb\bin\mongod.exe
This starts the main MongoDB database process. The waiting for connections message in the console output indicates that the mongod.exe process is running successfully.

/***** 5. Create Database files Create directories ***************/
Run in seperate command prompt as administrator
	1.C:\> mkdir c:\mongodb\database\data\db
	2.C:\> mkdir c:\mongodb\database\data\log
	
	1.C:\> mkdir c:\mongodb\database1\data\db
	2.C:\> mkdir c:\mongodb\database1\data\log
	
	
	1.C:\> mkdir c:\mongodb\database2\data\db
	2.C:\> mkdir c:\mongodb\database2\data\log


/***** 6. Create a configuration file.***************/
 Manually Create this file. -- Do not run, Just Jump to step 9;
	C:\mongodb\mongod.cfg

/***** 7. Install the MongoDB service.***************/
Install the MongoDB service by starting mongod.exe with the --install option and the -config option to specify the previously created configuration file.  -- Do not run, Just Jump to step 9;
	C:\mongodb\bin\mongod.exe --config "C:\mongodb\mongod.cfg" --install

/***** 8. Start the MongoDB service..***************/
	c:\>net start MongoDB -- Do not run, Just Jump to step 9;
	--Should give you message "The mongodb service was started successfully"


/**** 9. Corrections For setting replica #Main Concept ************/
	Run> C:\mongodb\bin\
	1. mongod.exe --config C:\mongodb\bin\mongod.cfg --serviceName MongoDB0 --serviceDisplayName MongoDB0 --install
	2. mongod.exe --config C:\mongodb\bin\mongod1.cfg --serviceName MongoDB1 --serviceDisplayName MongoDB1 --install
	3. mongod.exe --config C:\mongodb\bin\mongod2.cfg --serviceName MongoDB2 --serviceDisplayName MongoDB2 --install

	Run> net start MongoDB0
	Run> net start MongoDB1
	Run> net start MongoDB2

	Run> mongo MongoDB0 
	Run> config = { _id : "myReplSet",members : [ {_id : 0, host :"localhost:27017"}, 
	  {_id : 1, host : "localhost:27018"}, {_id : 2, host :"localhost:27019"},]}
  
	Run> rs.initiate(config)

	
/***** Stop or remove the MongoDB service as needed.***************/	
To stop the MongoDB service use the following command:	
	net stop MongoDB

To remove the MongoDB service use the following command:	
	"C:\mongodb\bin\mongod.exe" --remove
	OR
	mongod.exe --serviceName MongoDB  --remove

/**** Set up replica sets for MongoDb ******/
	c:\mongodb\bin\mongo MongoDB
	//http://www.codeproject.com/Articles/524602/Beginners-guide-to-using-MongoDB-and-the-offic
	The shell will connect to the MongoDB0 instance. Now initialise a variable called config by entering the following:

	config = { _id : "myReplSet",members : [ {_id : 0, host :"localhost:28017"}, 
	  {_id : 1, host : "localhost:27018"}, {_id : 2, host :"localhost:27019"},]}
	 
	 config = { _id : "myReplSet",members : [ {_id : 0, host :"localhost:28017"}, ]}
	 

/**** rs.initiate() *********/
rs.initiate(config)

	