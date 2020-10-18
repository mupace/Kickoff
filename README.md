This is a sample Umbraco website. 

I have tried to show how you can grab control over document types as well as simple usage of Umbraco. 

Normally, an Umbraco website can be created without any need of visual studio itself. However in order to achive high level implementations controls you will need to create controllers.

Here you can see Home and Standard pages are get built and error pages are just derives data in razor views. 

For example, over a property (Under Maintenance in Home), you can put site in maintenance mode in which no content page under Home node can be seen. 
This property is checked with an action filter hence this control is in controllers' action.

There is a caching mechanism based on content nodes and invalidations are triggered by Publish events. This means, whenever a content node is published; if node itself or any related node is cache; cache is invalidated. 
However caching data is done in builders.

I took leverage of 2 popular Umbraco addons (uSync and Umbraco Forms) for this project. uSync itself is not a functional addon, it is used for migration and version tracking for types.
On the other hand Umbraco Forms is used for dynamic form creation and flow management. 

Feel free to contact me on any questions via mehmet.tlk.avci@gmail.com

You can use following info to gain access to backoffice (/umbraco is open)

UserName: admin@sometempdomain.net
Password: Password12345