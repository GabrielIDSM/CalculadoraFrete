<template>
  <div class="Campo" :class="{ Erro: campo.errorMessage }">
    <label>{{ nome }}</label>
    <input
      @change="campo.validate"
      v-model="campo.value.value"
      :name="nome"
      autocomplete="off"
      type="number"
      :step="stepValue"
    />
    <span v-if="campo.errorMessage">{{ campo.errorMessage }}</span>
  </div>
</template>

<script setup lang="ts">
import { computed } from 'vue'

const stepValue = computed(() => (props.isInteiro ? 1 : 0.01))

const props = defineProps({
  nome: String,
  campo: {
    type: Object,
    required: true,
  },
  isInteiro: {
    type: Boolean,
    required: true,
  },
})
</script>
