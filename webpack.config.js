const path = require("path");

module.exports = {
  entry: {
    vendor: ["vue"],
    Fugo: "./src/page/Fugo/app.js"
  },
  output: {
    filename: "[name].bundle.js",
    path: path.resolve(__dirname, "wwwroot/dist")
  }
};
