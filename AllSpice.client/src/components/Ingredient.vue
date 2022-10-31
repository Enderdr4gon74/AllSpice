<template>
  <li class="d-flex gap-2">
    <p class="m-0"> - {{ingredient.quantity}} {{ingredient.name}}</p>
  </li>
</template>


<script>
import { Ingredient } from "../models/Ingredient.js"

export default {
  props: {
    ingredient: { type: Ingredient, required: true},
  },
  setup(){
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>