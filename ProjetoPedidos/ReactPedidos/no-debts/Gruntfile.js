module.exports = function(grunt) {
  require('jit-grunt')(grunt);

  grunt.initConfig({
    less: {
      development: {
        files: {
          "src/css/main.css": "src/css/main.less"
        }
      }
    },
    watch: {
      styles: {
        files: ['**/*.less'],
        tasks: ['less']
      }
    }
  });

  grunt.registerTask('default', ['less', 'watch']);
};