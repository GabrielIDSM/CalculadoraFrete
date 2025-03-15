<template>
  <div class="Campo" :class="{ Erro: campo.errorMessage }">
    <label>{{ nome }}</label>
    <money3 v-model.number="campo.value.value" v-bind="maskRealBrasileiro" />
    <span v-if="campo.errorMessage">{{ campo.errorMessage }}</span>
  </div>
</template>

<script setup lang="ts">
import { Money3Component } from 'v-money3'
import { defineComponent } from 'vue'

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

defineComponent({
  components: {
    money3: Money3Component,
  },
})

defineProps({
  nome: String,
  campo: {
    type: Object,
    required: true,
  },
})
</script>
