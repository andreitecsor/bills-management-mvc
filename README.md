# Web and Cloud - ASP.NET MVC

## BRIEF DESCRIPTION:
Enterprise Bills Management is an application that helps you keep track of bills for one or more companies. There are 3 roles:
- AuditBills (can only see the companies and bills)
	- email: audit@bills.ent
	- password: 345Secret@
- BillsWorker (AuditBills role permissions + CRUD operations on bills)
	- email: worker@bills.ent
	- password: 123!Secret
- BillsManagement (BillsWorker role permissions + CRUD operations on companies)
	- email: administrator@bills.ent
	- password: Secret123$

## COMPLETED TASKS:
- Create an application using ASP.NET Core 6.X on a topic of your choice, allowing users to perform CRUD operations on two related classes (ex: Product-Category). The application will be accessible only to authenticated users. The operations that the users will be able to perform will depend on their associated role(s).

Authentication
- change the minimum length of the password;
- lock the user out for 30 minutes after 5 unsuccessful attempts;
- the application will not allow unauthenticated users to register. The only users available in the application will be the ones that you are going to create in the "SeedDataIdentity" class (or in a class with another name, but with a similar purpose);

Authorization
- implement role-based authorization;
- use both imperative and declarative authorization;
- note: your application should use at least two different roles;

SSL
- redirect HTTP requests to HTTPS;
- send HTTP Strict Transport Security Protocol (HSTS) headers to clients; (In homework I used it for all environments, but it is recommended to be used only on production)

Other
- your forms should be protected against Cross-Site Request Forgery (CSRF) attacks;
