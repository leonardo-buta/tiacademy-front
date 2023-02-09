import { createWebHistory, createRouter } from "vue-router";
const routes = [
  {
    path: "/",
    component: () => import("./components/TheWelcome.vue")
  },
  {
    path: "/cliente/listar",
    component: () => import("./components/cliente/Listar.vue")
  },
  {
    path: "/cliente/cadastrar",
    component: () => import("./components/cliente/Cadastrar.vue")
  },
  {
    path: "/cliente/:id",
    component: () => import("./components/cliente/Atualizar.vue")
  }
];
const router = createRouter({
  history: createWebHistory(),
  routes
});
export default router;