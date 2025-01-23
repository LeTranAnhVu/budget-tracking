// eslint.config.mjs
import antfu from '@antfu/eslint-config'

export default antfu(
  {
    vue: true,
    typescript: true,
    css: true,
    html: true,
  },
  {
    files: ['**/*.ts', '**/*.vue'],
    rules: {
      // Explicit return types help with reading code in Pull Requests in Azure DevOps.
      '@typescript-eslint/explicit-function-return-type': ['error', { allowExpressions: true }],
      // Current consensus is to use braces https://eslint.org/docs/latest/rules/brace-style
      'style/brace-style': ['error', '1tbs'],
      // Concensus for formatting Vue attributes
      'vue/first-attribute-linebreak': ['error', {
        singleline: 'beside',
        multiline: 'below',
      }],
      'vue/max-attributes-per-line': ['error', {
        singleline: 1,
        multiline: 1,
      }],
    },
  },
)
