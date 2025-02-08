# TypeScript Type Declarations Note

## Overview
Type declarations in TypeScript help us:
- Add types to untyped code (JS libraries)
- Extend existing types
- Create global types
- Handle non-code files (.png, .json)

## Two Main Approaches

### 1. Reference Types (`/// <reference>`)
  ```typescript
  // USAGE: Import existing type definitions
  /// <reference types="vite/client" />

  // Common when:
  // - Extending library types
  // - Working with Vite, Node, etc.
  ```

### 2. Declare Types (`declare`)
  ```typescript
  // USAGE: Create new type definitions
  declare global {
    interface Window {
      myAPI: string
    }
  }

  // Common when:
  // - Creating new types
  // - Extending global interfaces
  // - Typing non-code files
  ```

## Common Use Cases

### 1. Extending Window
  ```typescript
  declare global {
    interface Window {
      myAPI: string
      helper(): void
    }
  }
  export {} // Required!
  ```

### 2. Vite Environment Variables
  ```typescript
  /// <reference types="vite/client" />
  interface ImportMetaEnv {
    readonly VITE_API_URL: string
  }
  ```

### 3. Module Declarations
  ```typescript
  declare module '*.png' {
    const value: string
    export default value
  }
  ```

## Important Rules

1. File Setup:
   - Use `.d.ts` extension
   - Include in `tsconfig.json`
   - Add `export {}` for global declarations

2. Location Options:
   - `src/types/`
   - `src/@types/`
   - Project root

3. Interface Merging:
   - TypeScript merges same-name interfaces
   - Works across files
   - Useful for extending types

## Troubleshooting

If types aren't working:
1. Check file extension (`.d.ts`)
2. Verify `tsconfig.json` includes file
3. Restart TS server
4. Add `export {}` for globals
5. Check library installations

## Best Practices

1. Keep declarations near usage
2. Use clear names
3. Document complex types
4. Avoid unnecessary globals
5. Prefer module augmentation when possible

Remember: Declarations are for development only - implement runtime functionality separately.

## Quick Reference

  ```typescript
  // Extending Window
  declare global {
    interface Window {
      api: { version: string }
    }
  }
  export {}

  // Environment Variables
  /// <reference types="vite/client" />
  interface ImportMetaEnv {
    readonly VITE_API_URL: string
  }

  // Custom Types
  declare type UserRole = 'admin' | 'user'
  declare interface ApiResponse<T> {
    data: T
    status: number
  }
  ```
