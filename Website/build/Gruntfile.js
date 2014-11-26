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

        // https://github.com/gruntjs/grunt-contrib-cssmin
        cssmin: {
            dev: {
                options: {
                    banner: '/* PayMe minified Style Sheet */'
                },
                files: [{
                    expand: true,
                    cwd: '../common/resources/css/',
                    src: ['*.css', '!*.min.css'],
                    dest: '../common/resources/css/',
                    ext: '.min.css'
                }]
            }
        },

        watch: {
            compass: {
                files: ['../common/resources/sass/**/*.{scss,sass}'],
                tasks: ['compass:dev']
            },

            styles: {
                files: ['../common/resources/*.css', '!../common/resources/*.min.css'],
                tasks: ['cssmin:dev']
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
    grunt.loadNpmTasks('grunt-contrib-cssmin');

    grunt.registerTask('default', ['compass:dev', 'cssmin:dev', 'watch']); //'watch');
};