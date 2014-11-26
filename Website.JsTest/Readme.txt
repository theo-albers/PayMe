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


