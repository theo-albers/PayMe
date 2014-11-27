See:
- https://chekkanz.wordpress.com/2014/03/31/setting-up-mocha-for-testing-angularjs-in-visual-studio-using-sinon-and-chai/
- http://chaijs.com/
- https://github.com/kmiyashiro/grunt-mocha
- http://fairwaytech.com/2014/01/understanding-grunt-part-2-automated-testing-with-mocha/
- http://phantomjs.org/headless-testing.html

Setup
-----
- add new, empty C# library project
- add build folder
- add package.json to build folder

	{
	  "name": "PayMe.Website.JsTest",
	  "version": "0.1.0",
	  "devDependencies": {
		"grunt": "^0.4.5"
	  }
	}

- install nodejs, http://nodejs.org/ (0.10.30 (x64)
- start nodejs command prompt and go to build folder
- from http://mochajs.org/#installation
	- npm install chai --save-dev
	- npm install mocha --save-dev
- from http://metaskills.net/mocha-phantomjs/
	- npm install mocha-phantomjs phantomjs --save-dev

- add chutzpah nuget packages
- http://mochajs.org/#installation
  npm install -g mocha
- download http://sinonjs.org/
- download http://chaijs.com/chai.js
- download https://github.com/domenic/sinon-chai/releases

Use Bower for client depends
----------------------------
- add bower, from the Website.JsTest.build folder using the nodejs command line:
	- npm install bower --save-dev
- now create a template bower.json file
	- node_modules\.bin\bower init

		{
	  "name": "PayMe.Website.JsTest",
	  "version": "1.0.0"
	}

- add .bowerrc file with configuration to override the default folder
	{
	  "directory": "../vendor/",
	  "analytics": false
	}

- add required packages to fill the bower.json
	- node_modules\.bin\bower install chai --save-dev
	- node_modules\.bin\bower install mocha --save-dev

- in a clean site, simply restore the packages:
	- node_modules\.bin\bower install

Note: we get a lot better support in VS2015, http://www.asp.net/vnext/overview/aspnet-vnext/grunt-and-bower-in-visual-studio-2015.
Still we want a better structure for the bower package files, the core JS and CSS stuff. 
See:
- http://stackoverflow.com/questions/25023612/bower-and-gruntjs-concatenating-vendor-javascript-into-one-file
- https://www.npmjs.org/package/bower-copy