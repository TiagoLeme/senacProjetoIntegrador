<template>
  <div class="container">
    <div class="form">
      <h1 id="title">Login</h1>
      <input type="text" placeholder="Login" class="input" v-model="data.login" />
      <input type="password" placeholder="Senha" class="input" v-model="data.senha" />
      <Button class="button" @click="login">Entrar</Button>
    </div>
  </div>
</template>

<script setup>
import loginBurger from "@/assets/bg-login.png";
import { BASEURL } from "../../env";
import { useRouter } from "vue-router";
import Button from "../components/Button.vue";

const router = useRouter();

const data = {
  login: "",
  senha: "",
};

async function login() {
  try {
    const response = await fetch(`${BASEURL}/api/Auth/Login`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    });

    if (response.ok) {
      const responseData = await response.json();
      localStorage.setItem("token", `bearer ${responseData.bearerToken}`);
      localStorage.setItem("permission", data.login);
      if (data.login === 'administrador') {
        router.push("/manager")
      } else if (data.login === 'atendente') {
        router.push("/attendant/home");
      } else {
        router.push("/products");
      }
    } else {
      console.error("Erro na solicitação POST. Código de status:", response.status);
    }
  } catch (error) {
    console.error("Erro na solicitação POST:", error);
  }
}
</script>

<style scoped>
.container {
  background-image: url("@/assets/bg-login.jpg");
  display: flex;
  background-size: cover;
  justify-content: center;
  align-items: center;
  height: 100vh;
  max-width: 100vw;
  margin: -3.2em;
}

.form {
  padding: 2em;
  width: 25vw;
  height: 50vh;
  border-radius: 5px;
  background-color: #f7f7f7;
  display: flex;
  flex-direction: column;
  justify-content: center;
}

.input {
  width: 100%;
  padding: 15px;
  margin: 1em 0;
  border: 1px solid #ccc;
  border-radius: 5px;
  outline: none;
}


#title {
  color: #9758a6;
}

.input::placeholder {
  color: #101010;
}

#image {
  margin: -5em 0 -5em -1em;
  height: 100vh;
}

@media (max-width: 1500px) {
  .form {
    width: 30vw;
    height: 70vh;
  }
}

@media (max-width: 500px) {
  .form {
    width: 100vw;
    height: 100vh;
  }
}
</style>
