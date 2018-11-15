const path = require("path");
const VueLoaderPlugin = require("vue-loader/lib/plugin.js");

module.exports = {
  context: path.resolve(__dirname, "src"),
  entry: {
    // vendor: ["vue"],
    Fugo: "./page/Fugo/app.js",
    Sample: "./page/Sample/app.js"
  },
  output: {
    filename: "[name].bundle.js",
    path: path.resolve(__dirname, "wwwroot/dist")
  },
  module: {
    rules: [
      {
        test: /\.vue$/,
        loader: "vue-loader",
        include: path.resolve(__dirname, "src")
      },
      {
        test: /\.js$/,
        loader: "babel-loader",
        include: path.resolve(__dirname, "src")
      },
      {
        test: /\.css$/,
        use: ["vue-style-loader", "css-loader"]
      }
    ]
  },
  plugins: [
    // make sure to include the plugin!
    new VueLoaderPlugin()
  ],
  resolve: {
    alias: {
      vue: "vue/dist/vue.js"
    }
  }
};
