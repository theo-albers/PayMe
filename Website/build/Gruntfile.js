// following http://matthew-jackson.com/notes/development/grunt-workflow-for-sass-compass-and-js/
// and http://moduscreate.com/get-up-and-running-with-grunt-js/
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