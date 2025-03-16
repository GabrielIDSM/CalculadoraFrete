<template></template>

<script setup lang="ts">
import type { PropType } from 'vue'
import type { Resposta } from '@/types/Frete'

const props = defineProps({
  resposta: {
    type: Object as PropType<Resposta>,
    required: true,
  },
  index: Number,
})
</script>
