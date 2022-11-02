import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  
  /** @type {import('./models/Recipe.js').Recipe[] | null} */
  recipes: null,

  /** @type {import('./models/Recipe.js').Recipe[] | null} */
  hiddenRecipes: null,
  
  /** @type {import('./models/Recipe.js').Recipe | null} */
  activeRecipe: null,
  
  /** @type {import('./models/Ingredient.js').Ingredient[] | null} */
  ingredients: null,

  /** @type {import('./models/Favorite.js').Favorite[] | []} */
  favorites: [],

  currentFilter: 0,

  filterName: "",
})
