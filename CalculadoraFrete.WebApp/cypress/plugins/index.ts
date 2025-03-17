import { defineConfig } from 'cypress'
import { devServer } from '@cypress/vite-dev-server'

export default defineConfig({
  e2e: {
    baseUrl: 'http://localhost:3002',
    supportFile: false,
    setupNodeEvents(on, config) {
      on('dev-server:start', (options) => {
        return devServer({
          ...options,
          viteConfig: {
            configFile: 'vite.config.ts',
          },
        })
      })

      return config
    },
  },
})
