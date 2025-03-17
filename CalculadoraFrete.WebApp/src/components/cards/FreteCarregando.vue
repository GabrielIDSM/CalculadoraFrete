<template>
  <section class="Frete FreteCarregando"></section>
</template>

<style scoped>
.Frete {
  padding: 8px;
  height: 120px;
  border-radius: 8px;
  border: solid 1px rgba(var(--van-dyke), 0.6);
  background: linear-gradient(
    90deg,
    rgba(var(--van-dyke), 0.5),
    rgba(var(--van-dyke), 0.1),
    rgba(var(--van-dyke), 0.5)
  );
  background-size: 200% 100%;
  animation: shimmer 3s infinite linear;
}

@keyframes shimmer {
  0% {
    background-position: -200% 0;
  }
  100% {
    background-position: 200% 0;
  }
}
</style>
