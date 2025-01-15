import globals from "globals";
import babelParser from "@babel/eslint-parser";
import js from "@eslint/js";
import svelteParser from "svelte-eslint-parser";
//import eslintPluginSvelte from "eslint-plugin-svelte";

export default [
    // add more generic rule sets here, such as:
    js.configs.recommended,
    // TODO: A config object is using the "extends" key, which is not supported in flat config system.
    //eslintPluginSvelte.configs.recommended,
    {
        ignores: [
            "**/.DS_Store",
            "**/node_modules",
            "build",
            ".svelte-kit",
            "package",
            "**/.env",
            "**/.env.*",
            "!**/.env.example",
            "**/pnpm-lock.yaml",
            "**/package-lock.json",
            "**/yarn.lock",
        ],
    },
    {
        files: ["**/*.svelte", "*.svelte"],
        languageOptions: {
            parser: svelteParser,
        },
    },
    {
        languageOptions: {
            globals: {
                ...globals.browser,
                ...globals.node,
            },
            parser: babelParser,
            parserOptions: {
                requireConfigFile: false,
            },
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
            "no-unused-vars": ["warn", { "args": "none" }],
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
    },
];
