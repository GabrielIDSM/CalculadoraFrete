<template>
  <section class="Formulario">
    <form @submit.prevent="submitForm">
      <input
        v-model="form.CEPOrigem"
        v-imask="{ mask: '00000-000' }"
        type="text"
        placeholder="CEP Origem"
        required
      />
      <input
        v-model="form.CEPDestino"
        v-imask="{ mask: '00000-000' }"
        type="text"
        placeholder="CEP Destino"
        required
      />
      <input v-model.number="form.Peso" type="number" placeholder="Peso (kg)" required />
      <input v-model.number="form.Largura" type="number" placeholder="Largura (cm)" required />
      <input v-model.number="form.Altura" type="number" placeholder="Altura (cm)" required />
      <input
        v-model.number="form.Comprimento"
        type="number"
        placeholder="Comprimento (cm)"
        required
      />
      <input
        v-model.number="form.ValorDeclarado"
        type="number"
        placeholder="Valor Declarado (R$)"
        required
      />
      <button type="submit">Calcular Frete</button>
    </form>
  </section>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import type { ParametroEnvio } from '@/types/Frete'

const form = ref<ParametroEnvio>({
  CEPOrigem: '',
  CEPDestino: '',
  Peso: 0,
  Largura: 0,
  Altura: 0,
  Comprimento: 0,
  ValorDeclarado: 0,
})

const emit = defineEmits<{
  (e: 'calcular-frete', parametros: ParametroEnvio): void
}>()

const submitForm = () => {
  emit('calcular-frete', { ...form.value })
}
</script>
