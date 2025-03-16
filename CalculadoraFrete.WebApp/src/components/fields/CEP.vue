<template>
  <div class="Campo" :class="{ Erro: campo.errorMessage }">
    <label>{{ nome }}</label>
    <input
      @change="campo.validate()"
      v-model="campo.value.value"
      v-imask="{ mask: '00000-000' }"
      maxlength="9"
      type="text"
    />
    <span v-if="campo.errorMessage">{{ campo.errorMessage }}</span>
  </div>
</template>

<script setup lang="ts">
defineProps({
  nome: String,
  campo: {
    type: Object,
    required: true,
  },
})
</script>
