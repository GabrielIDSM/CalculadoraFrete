import { defineStore } from 'pinia'
import { ref, watch } from 'vue'
import type { Resposta } from '../types/Frete'

const STORAGE_KEY = 'freteStore'
const CACHE_DURATION = 15 * 60 * 1000

export const useFreteStore = defineStore('frete', () => {
  const historico = ref<Resposta[]>([])

  const carregarCache = () => {
    const cache = localStorage.getItem(STORAGE_KEY)
    if (cache) {
      const { data, timestamp } = JSON.parse(cache)
      const agora = Date.now()

      if (agora - timestamp < CACHE_DURATION) {
        historico.value = data
      } else {
        localStorage.removeItem(STORAGE_KEY)
      }
    }
  }

  watch(
    historico,
    () => {
      localStorage.setItem(
        STORAGE_KEY,
        JSON.stringify({ data: historico.value, timestamp: Date.now() }),
      )
    },
    { deep: true },
  )

  const adicionarCotacaoTemporaria = (cotacaoTemporaria: Resposta) => {
    historico.value.unshift(cotacaoTemporaria)
  }

  const adicionarCotacao = (novaCotacao: Resposta) => {
    historico.value[0] = novaCotacao
  }

  carregarCache()

  return { historico, adicionarCotacao, adicionarCotacaoTemporaria }
})
