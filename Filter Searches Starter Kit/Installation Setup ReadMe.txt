Filter Searches Setup ReadMe file

This file will help you place the Filter Searches code correctly in your existing classroom solution sample

This setup assumes the following structure of your solution. If your project or folder names are different, you will need to adjust the Namespaces of the supplied code for it to work.

Data project

Northwind.Data
project folders (only the folders being affected are listed)
	Entities
	Views (you will need to make this folder)

Component Library project

NorthwindSystem
project folders (only the folders being affected are listed)
	BLL
	DAL

Web Application project

WebApp
project folders (only the folders being affected are listed)
	Content
	NorthwindPages

Setup Steps
Open your solution. Some of the setup will be done by copy and paste of the entire file (best done using Windows Explorer). Some of the setup will be done inside existing solution files.

Northwind.Data project
	Entities
		Under the Entities and Views/Entities you will find 2 new entity classes: Region and Territory.
		Copy and Paste these new classes under your Entities folder
	Views
		Create a new folder by this name in your project. 
		Under the Entities and Views/Views you will find 2 new data classes: EmployeeOfTerritory and SupplierCategories.
		Copy and Paste these new classes under the Views folder

NorthwindSystem project
	DAL
		Add the DbSet<> for Region and Territory to your context class (view the supplied context class)
	BLL
		There are 3 current controllers in your project: ProductController, CategoryController, SupplierController.
		Open one of these current controllers in your project. Open the corresponding controller found in the setup BLL folder.
		Compare the two files. Add (copy and paste) any of the methods found in the setp controller that are not in your current controller.
		Repeat for the other 2 current controllers.		
		There are 3 new controllers: EmployeeController, RegionController, TerritoryController.
		Copy and paste these 3 new controllers into your BLL folder.
		
Web Application Project
	Content
		Copy and paste the file found in the setup Content folder to your WebApp Content folder
	NorthWindPages
		Copy and paste the web page FilterSearches from the setup folder to your WebApp folder NorthwindPages
	Site.master
		Add a new menu item to your site menu to reference the new web page FilterSearches.

SQL Database.
	Make sure you have the most recent sql .bak file of Northwind_CPSC1517 restored to your machine. If you are in doubt, use the .bak file supplied in this start kit.

Compile your solution.
Run your solution.