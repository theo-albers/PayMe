# sass folder is the same location as this config.rb file
config_path = File.dirname(__FILE__)
sass_path = File.join(config_path, "..", "common", "resources", "sass")
css_path = File.join(config_path, "..", "common", "resources", "css")

# output_style: The output style for your compiled CSS
# nested, expanded, compact, compressed
# More information can be found here http://sass-lang.com/docs/yardoc/file.SASS_REFERENCE.html#output_style
output_style = :expanded


