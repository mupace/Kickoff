This is a sample Umbraco website. 

I have tried to show how you can grab control over document types as well as simple usage of Umbraco. 

Normally, any Umbraco website can be created without any need of visual studio itself. However in order to achive high level implementations, mergers and controls you will need to create controllers and jump in.

Here you can see Home and Standard pages are get built and error pages are just derives data in razor views. 

For example, over a property (Under Maintenance in Home), you can put site in maintenance mode in which no content page under Home node can be seen. 
This property is checked with an action filter hence this control is in controllers' action.