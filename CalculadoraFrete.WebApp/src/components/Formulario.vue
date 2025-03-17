<template>
  <section class="Formulario">
    <div class="Conteudo">
      <form @submit.prevent="submitForm">
        <CEP :nome="'CEP de origem'" :campo="form.CEPOrigem" />
        <CEP :nome="'CEP de destino'" :campo="form.CEPDestino" />
        <Numero :nome="'Peso'" :campo="form.Peso" :isInteiro="false" />
        <Numero :nome="'Largura'" :campo="form.Largura" :isInteiro="true" />
        <Numero :nome="'Altura'" :campo="form.Altura" :isInteiro="true" />
        <Numero :nome="'Comprimento'" :campo="form.Comprimento" :isInteiro="true" />
        <RealBrasileiro :nome="'Valor declarado'" :campo="form.ValorDeclarado" />
        <button class="btn" type="submit">Calcular Frete</button>
      </form>
    </div>
  </section>
</template>

<style scoped>
.Formulario {
  padding: 40px 0;
  background-color: rgba(var(--off-white), 1);
}

form {
  display: flex;
  flex-wrap: wrap;
  gap: 16px 10px;
}

button {
  margin-top: 20px;
  padding: 12px;
  flex: 1 1 100%;
  border-radius: 50px;
  color: rgba(var(--off-white), 1);
  background-color: rgba(var(--van-dyke), 0.9);
}

button:hover {
  color: rgba(var(--off-white), 1);
  background-color: rgba(var(--van-dyke), 1);
}
</style>

<script setup lang="ts">
import CEP from '@/components/fields/CEP.vue'
import Numero from '@/components/fields/Numero.vue'
import RealBrasileiro from '@/components/fields/RealBrasileiro.vue'
import type { ParametroEnvio } from '@/types/Frete'
import { useForm, useField } from 'vee-validate'
import * as yup from 'yup'

const schema = yup.object({
  CEPOrigem: yup
    .string()
    .transform((value) => value.replace(/\D/g, ''))
    .length(8, 'O CEP de origem deve ter o formato 12345-123')
    .required('CEP de origem é obrigatório'),
  CEPDestino: yup
    .string()
    .transform((value) => value.replace(/\D/g, ''))
    .length(8, 'O CEP de origem deve ter o formato 12345-123')
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
</script>
