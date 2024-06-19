module.exports = {
    root: true,
    extends: [
        // add more generic rule sets here, such as:
        "eslint:recommended",
        "plugin:svelte/recommended",
    ],
    overrides: [
        {
            files: ["*.svelte"],
            parser: "svelte-eslint-parser",
        },
    ],
    parser: "@babel/eslint-parser",
    parserOptions: {
        requireConfigFile: false,
        sourceType: "module",
        ecmaVersion: 2020,
    },
    env: {
        browser: true,
        es2017: true,
        node: true,
    },
    rules: {
        "yoda": "warn",
        eqeqeq: ["warn", "smart"],
        indent: ["warn", 4, { "SwitchCase": 1 }],
        quotes: ["warn", "double"],
        semi: ["off", "never"],
        "no-multi-spaces": ["warn", { ignoreEOLComments: true }],
        "curly": "off",
        "comma-spacing": "warn",
        "brace-style": ["off"],
        "no-var": "warn",
        "key-spacing": "warn",
        "keyword-spacing": "warn",
        "space-infix-ops": "warn",
        "arrow-spacing": "warn",
        "no-trailing-spaces": "off",
        "space-before-blocks": "warn",
        "no-unused-vars": ["warn", {
            "args": "none",
        }],
        "no-console": "off",
        "no-extra-boolean-cast": "off",
        "no-multiple-empty-lines": ["warn", { "max": 1, "maxBOF": 0 }],
        "lines-between-class-members": ["warn", "always", { exceptAfterSingleLine: true }],
        "no-unneeded-ternary": "warn",
        "no-else-return": ["warn", { "allowElseIf": false }],
        "array-bracket-newline": ["warn", "consistent"],
        "eol-last": ["warn", "always"],
        "prefer-template": "warn",
        "template-curly-spacing": ["warn", "never"],
        "comma-dangle": ["off"],
    }
};
