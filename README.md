# aurelia-mvc
Example project for combining Aurelia with MVC

Aurelia (http://aurelia.io/) is an amazing web framework. It's designed to work through Nodejs, but it can function very well with the .Net technology stack. Basically, my goal in this project was to combine MVC routing and Aurelia routing. Each section (Home, About, etc) is handled by MVC and within the section Aurelia picks up the routing responsibilities. 

Some example code was taken from: http://odetocode.com/blogs/scott/archive/2015/04/07/aurelia-hello-world-with-asp-net-5.aspx

Getting started steps: 
1. Create a new, empty ASP.NET 5 web application with Visual Studio 2015

2. Install JSPM

3. Perform the following commands:
jspm install aurelia-framework
During the first installation, JSPM will do some configuration settings. Most of the settings can be default, but set the base folder to: "./wwwroot".
jspm install aurelia-bootstrapper

4. Now, in the project root (not the wwwroot folder), create a folder called Views. Within that folder, you can create any subfolder for any section of your app you'd like. For example, "Home".

5. Within the Home folder, create an Index.cshtml file. Within that file, add the following: 
```html
        <body aurelia-app="/AureliaConfigurations/home">
        </body>
```

6. What this does is tell Aurelia to bootstrap the body of any later loaded templates (we'll get to that). It also gives a particular configuration, which is important to having multiple main sections.

7. Within wwwroot create a folder called AureliaConfigurations and create a home.js file. Add the following:
```javascript

        import {LogManager} from 'aurelia-framework';
        import {ConsoleAppender} from 'aurelia-logging-console';
        
        LogManager.addAppender(new ConsoleAppender());
        LogManager.setLevel(LogManager.logLevel.debug);
        
        export function configure(aurelia) {
            aurelia.use
              .defaultBindingLanguage()
              .defaultResources()
              .history()
              .router()
              .eventAggregator();
        
            aurelia.start().then(a => a.setRoot('/views/home/app', document.body));
        }

```

By default, Aurelia looks for an app.js file in the same directory as the Index.html (or cshtml in our case), this overrides that behaivor. This is what allows us to have multiple subapps within our main application.

8. Now within wwwroot create a folder called Views with the same subfolders as our other views folder. 

9. Create 2 files in the home directory: app.js and app.html. Add the following code to each (from the Aurelia getting started docs).

app.html
```html

        <template>
            <require from="./nav-bar.html"></require>
            <link rel="stylesheet" type="text/css" href="jspm_packages/github/twbs/bootstrap@3.3.5/css/bootstrap.css" />
        
          <nav-bar router.bind="router"></nav-bar>
        
          <div class="page-host">
            <router-view></router-view>
          </div>
        </template>


```

app.js
```javascript

        export class App {
          configureRouter(config, router) {
            config.title = 'Aurelia';
            config.map([
              { route: ['', 'welcome'], name: 'welcome',      moduleId: './welcome',      nav: true, title: 'Welcome' },
              { route: 'users',         name: 'users',        moduleId: './users',        nav: true, title: 'Github Users' },
              { route: 'child-router',  name: 'child-router', moduleId: './child-router', nav: true, title: 'Child Router' }
            ]);
        
            this.router = router;
          }
        }

```

You'll also need the html/js pairs found in the example app home directory (child-router, nav-bar, users, welcome)

10. In the Project/Views folder create a folder called Shared. Add a _Layout.cshtml file with the following:

```html

        <!DOCTYPE html>
        
        <html>
        <head>
            <meta name="viewport" content="width=device-width" />
            <title>@ViewBag.Title</title>
            <script src="~/jspm_packages/system.js"></script>
            <script src="~/config.js"></script>
            <script>
                System.import("aurelia-bootstrapper");
            </script>
        </head>
        <body>
            <div>
                @RenderBody()
            </div>
        </body>
        </html>

```

That brings in the needed javascript libraries. 

Outside of that folder create a _ViewStart.cshtml file that just applies our layout

```html
        
        @{
            Layout = "_Layout";
        }

```

11. Now create a controllers folder in the project root and create a HomeController that just returns the default view.

That should be it! If all has gone according to plan, your /home should bring up the a navigation page that you can switch between a couple of example pages. So that's it. MVC handles routing to our Aurelia application, which handles routing from there. This allows you to break your website into main sections governed by MVC and let Aurelia handle routing within.

In the example application, there are a few other concepts demonstrated, including constructor injection, using the Aurelia http library to very easily call a WebApi service method and bind the results. It's all very simple and easy to do with Aurelia, so give it a look.
