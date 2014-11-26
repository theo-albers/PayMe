
Creating website project:
- New ASP.NET Web Application, Empty
- turn into Katana site http://www.asp.net/aspnet/overview/owin-and-katana/getting-started-with-owin-and-katana
  - install-package Microsoft.Owin.Host.SystemWeb
  - install-package Microsoft.Owin.Diagnostics
  - Install-Package Microsoft.AspNet.WebApi.Owin

Adding Code Contracts support:
- http://mediocresoft.com/things/code-contracts-from-new-project-to-nuget
- http://research.microsoft.com/en-us/projects/contracts/userdoc.pdf
- Need to set the build configuration

To add:
- DI via Autofac http://blogs.msdn.com/b/roncain/archive/2012/07/16/dependency-injection-with-asp-net-web-api-and-autofac.aspx
- AngularJS
- dispose of DbContext

To explore:
- https://www.firebase.com/




How to add SASS support
-----------------------
Create SASS files in website project:
- create package "common" under Website and add resources/sass, fonts, images and css folders
- add File New in VS and add "SCSS Style Sheet (SASS)" items _environment, _colors and common-style.
  the _ files are ignored later on in the compilation step.

Add the tooling to compile SASS files and minify them:
- note: I don't use SASS support in VS2013 via Web Essentials 2013 for Update 4 because of the issues related with that package.
- install compass to compile SASS
	- install Ruby https://www.ruby-lang.org/en/downloads/, for Windows use http://rubyinstaller.org/, using Ruby 2.1.5 (x64)
	- install compass http://compass-style.org/install/ from ruby command prompt
		- gem update --system
		- gem install compass
- install grunt. Grunt is a javascript task runner, in that it is written in Javascript 
  (using Node JS) and it runs tasks. Grunt uses 2 files - a package.json (which tells 
  grunt what all the dependencies it needs are) and a Gruntfile.
	- install nodejs, http://nodejs.org/ (0.10.30 (x64)
	- install grunt, http://gruntjs.com/getting-started (0.3.1) from nodejs command prompt
		- npm install -g grunt-cli
		  This will put the grunt command in your system path, allowing it to be run from any directory.
    - install grunt-init to create a template project.json, http://gruntjs.com/project-scaffolding
		- npm install -g grunt-init
	- install grunt for SASS https://github.com/gruntjs/grunt-contrib-sass
		- npm install grunt-contrib-sass --save-dev

Add grunt SASS task to website project:
- add package.json packages file to project following http://matthew-jackson.com/notes/development/grunt-workflow-for-sass-compass-and-js/
	- add package.json skeleton file (which can also be generate via npm) 
	  See also 
		- http://docs.nodejitsu.com/articles/getting-started/npm/what-is-the-file-package-json
		- http://gruntjs.com/project-scaffolding
		- http://gruntjs.com/getting-started.

		{
		"name": "PayMe.Website",
		"version": "0.1.0",
		"devDependencies": {
		"grunt": "^0.4.5"
		}
	}

	- start NodeJS command line and go to the website folder
	- add grunt watch plugin (this will update the package.json file):
		- npm install grunt-contrib-watch --save-dev
	- add compass and uglify:
		- npm install grunt-contrib-compass --save-dev
		- npm install grunt-contrib-uglify --save-dev
	- now our package.json looks like:

		{
	  "name": "PayMe.Website",
	  "version": "0.1.0",
	  "devDependencies": {
		"grunt": "^0.4.5",
		"grunt-contrib-compass": "^1.0.1",
		"grunt-contrib-uglify": "^0.6.0",
		"grunt-contrib-watch": "^0.6.1"
	  }
	}

- add config.rb to website project:

	# sass folder is the same location as this config.rb file
	config_path = File.dirname(__FILE__)
	sass_path = File.join(config_path, "common", "resources", "sass")
	css_path = File.join(config_path, "common", "resources", "css")

	# output_style: The output style for your compiled CSS
	# nested, expanded, compact, compressed
	# More information can be found here http://sass-lang.com/docs/yardoc/file.SASS_REFERENCE.html#output_style
	output_style = :expanded

- add Gruntfile.js to website project:

	module.exports = function (grunt) {
		grunt.initConfig({
			pkg: grunt.file.readJSON('package.json'),

			compass: {
				dev: {
					options: {
						config: 'config.rb',
						force: true
					}
				}
			},

			watch: {
				compass: {
					files: ['../common/resources/sass/**/*.{scss,sass}'],
					tasks: ['compass:dev']
				},

				/* watch our files for change, reload */
				livereload: {
					files: ['../common/resources/css/*.css'],
					options: {
						livereload: true
					}
				}
			}

		});

		// load all grunt tasks
		//require('matchdep').filterDev('grunt-*').forEach(grunt.loadNpmTasks);

		grunt.loadNpmTasks('grunt-contrib-watch');
		grunt.loadNpmTasks('grunt-contrib-compass');

		//grunt.registerTask('dev', ['compass:dev']);
		//grunt.registerTask('w', ['watch']);
		grunt.registerTask('default', 'watch');
	};

See also:
http://matthew-jackson.com/notes/development/setting-up-grunt-from-scratch/
http://matthew-jackson.com/notes/development/grunt-workflow-for-sass-compass-and-js/