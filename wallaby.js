module.exports = wallaby => {
  process.env.VUE_CLI_BABEL_TRANSPILE_MODULES = true;

  return {
    files: ["src/**/*", "jest.config.js", "package.json"],

    tests: ["tests/**/*.spec.js"],

    env: {
      type: "node",
      runner: "node"
    },

    compilers: {
      "**/*.vue": require("wallaby-vue-compiler")(wallaby.compilers.babel({}))
    },

    preprocessors: {
      "**/*.vue": file => require("vue-jest").process(file.content, file.path)
    },

    setup: function(wallaby) {
      const jestConfig = require("./package").jest || require("./jest.config");
      jestConfig.transform = {};
      wallaby.testFramework.configure(jestConfig);
    },

    testFramework: "jest",

    debug: true
  };
};
