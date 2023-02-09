<template>
    <h2>Cadastro de cliente</h2>
    <div class="col-4">
        <div class="form-group">
            <label>Nome</label>
            <input type="text" v-model="cliente.nome" class="form-control" placeholder="Digite seu nome">
            <label v-if="validacoes.nome" style="color:red">Nome não pode ser vazio</label>
        </div>
        <div class="form-group">
            <label>Login</label>
            <input type="text" v-model="cliente.login" class="form-control" placeholder="Digite seu login">
        </div>
        <div class="form-group">
            <label>Senha</label>
            <input type="password" v-model="cliente.senha" class="form-control">
        </div>
        <button type="submit" @click="cadastrarCliente" class="btn btn-primary">Cadastrar</button>
    </div>
</template>
<script>
import ClienteDataService from '../../services/ClienteDataService'

export default {
    data() {
        return {
            cliente: {
                nome: '',
                login: '',
                senha: ''
            },
            validacoes: {
                nome: false
            }
        }
    },
    methods: {
        cadastrarCliente() {
            if (this.cliente.nome == '') {
                this.validacoes.nome = true;
                return;
            }

            ClienteDataService.cadastrar(this.cliente)
                .then(() => {
                    this.$router.push('listar');
                });
        }
    }
}

</script>