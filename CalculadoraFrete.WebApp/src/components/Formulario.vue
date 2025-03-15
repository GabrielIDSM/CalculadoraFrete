<template>
  <section class="Formulario">
    <form @submit.prevent="submitForm">
      <div class="Campo" :class="{ Erro: form.CEPOrigem.errorMessage }">
        <label>CEP de origem</label>
        <input
          @change="form.CEPOrigem.validate()"
          v-model="form.CEPOrigem.value.value"
          v-imask="{ mask: '00000-000' }"
          type="text"
        />
        <span v-if="form.CEPOrigem.errorMessage">{{ form.CEPOrigem.errorMessage }}</span>
      </div>
      <div class="Campo" :class="{ Erro: form.CEPDestino.errorMessage }">
        <label>CEP de destino</label>
        <input
          @change="form.CEPDestino.validate()"
          v-model="form.CEPDestino.value.value"
          v-imask="{ mask: '00000-000' }"
          type="text"
        />
        <span v-if="form.CEPDestino.errorMessage">{{ form.CEPDestino.errorMessage }}</span>
      </div>
      <div class="Campo" :class="{ Erro: form.Peso.errorMessage }">
        <label>Peso</label>
        <input
          @change="form.Peso.validate()"
          v-model="form.Peso.value.value"
          type="number"
          step="0.01"
        />
        <span v-if="form.Peso.errorMessage">{{ form.Peso.errorMessage }}</span>
      </div>
      <div class="Campo" :class="{ Erro: form.Largura.errorMessage }">
        <label>Largura</label>
        <input
          @change="form.Largura.validate()"
          v-model="form.Largura.value.value"
          type="number"
          step="1"
        />
        <span v-if="form.Largura.errorMessage">{{ form.Largura.errorMessage }}</span>
      </div>
      <div class="Campo" :class="{ Erro: form.Altura.errorMessage }">
        <label>Altura</label>
        <input
          @change="form.Altura.validate()"
          v-model="form.Altura.value.value"
          type="number"
          step="1"
        />
        <span v-if="form.Altura.errorMessage">{{ form.Altura.errorMessage }}</span>
      </div>
      <div class="Campo" :class="{ Erro: form.Comprimento.errorMessage }">
        <label>Comprimento</label>
        <input
          @change="form.Comprimento.validate()"
          v-model="form.Comprimento.value.value"
          type="number"
          step="1"
        />
        <span v-if="form.Comprimento.errorMessage">{{ form.Comprimento.errorMessage }}</span>
      </div>
      <div class="Campo" :class="{ Erro: form.ValorDeclarado.errorMessage }">
        <label>Valor declarado</label>
        <money3 v-model.number="form.ValorDeclarado.value.value" v-bind="maskRealBrasileiro" />
        <span v-if="form.ValorDeclarado.errorMessage">{{ form.ValorDeclarado.errorMessage }}</span>
      </div>
      <button type="submit">Calcular Frete</button>
    </form>
  </section>
</template>

<script setup lang="ts">
import { defineComponent, ref } from 'vue'
import { useForm, useField } from 'vee-validate'
import * as yup from 'yup'
import type { ParametroEnvio } from '@/types/Frete'
import { Money3Component } from 'v-money3'

const schema = yup.object({
  CEPOrigem: yup
    .string()
    .transform((value) => value.replace('-', ''))
    .length(8, 'O CEP de origem deve ter o formato 12345-123')
    .required('CEP de origem é obrigatório'),
  CEPDestino: yup
    .string()
    .transform((value) => value.replace('-', ''))
    .length(8, 'O CEP de destino deve ter o formato 12345-123')
    .required('CEP de destino é obrigatório'),
  Peso: yup
    .number()
    .transform((value, originalValue) => (originalValue === '' ? null : value))
    .min(0.1, 'O peso deve ser maior ou igual 0.1 kg')
    .required('Peso é obrigatório'),
  Largura: yup
    .number()
    .transform((value, originalValue) => (originalValue === '' ? null : value))
    .integer()
    .min(1, 'A largura deve ser maior ou igual a 1 cm')
    .required('Largura é obrigatória'),
  Altura: yup
    .number()
    .transform((value, originalValue) => (originalValue === '' ? null : value))
    .integer()
    .min(1, 'A altura deve ser maior ou igual a 1 cm')
    .required('Altura é obrigatória'),
  Comprimento: yup
    .number()
    .transform((value, originalValue) => (originalValue === '' ? null : value))
    .integer()
    .min(1, 'O comprimento deve ser maior ou igual a 1 cm')
    .required('Comprimento é obrigatória'),
  ValorDeclarado: yup
    .number()
    .transform((value, originalValue) => (originalValue === '' ? null : value))
    .min(0.01, 'O valor declarado deve ser maior que R$ 0,01')
    .required('Valor declarado é obrigatório'),
})

const maskRealBrasileiro = {
  masked: false,
  prefix: 'R$ ',
  thousands: '.',
  decimal: ',',
  precision: 2,
  disableNegative: false,
  min: 0.0,
  shouldRound: true,
}

const { handleSubmit } = useForm({ validationSchema: schema })

const form = {
  CEPOrigem: useField<string>('CEPOrigem'),
  CEPDestino: useField<string>('CEPDestino'),
  Peso: useField<number>('Peso'),
  Largura: useField<number>('Largura'),
  Altura: useField<number>('Altura'),
  Comprimento: useField<number>('Comprimento'),
  ValorDeclarado: useField<number | null>('ValorDeclarado', undefined, {
    initialValue: 0.01,
  }),
}

const emit = defineEmits<{
  (e: 'calcular-frete', parametros: ParametroEnvio): void
}>()

const submitForm = handleSubmit((values) => {
  emit('calcular-frete', { ...(values as ParametroEnvio) })
})

defineComponent({
  components: {
    money3: Money3Component,
  },
})
</script>
