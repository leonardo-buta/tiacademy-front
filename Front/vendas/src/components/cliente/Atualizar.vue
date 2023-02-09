<template>
    <h2>Atualização de cliente</h2>
    <div class="col-4">
        <div class="form-group">
            <label>Nome</label>
            <input type="text" v-model="cliente.nome" class="form-control" placeholder="Digite seu nome">
            <label v-if="validacoes.nome" style="color:red">Nome não pode ser vazio</label>
        </div>
        <div class="form-group">
            <label>Login</label>
            <input type="text" disabled v-model="cliente.login" class="form-control" placeholder="Digite seu login">
        </div>
        <div class="form-group">
            <label>Senha</label>
            <input type="password" v-model="cliente.senha" class="form-control">
        </div>
        <button type="submit" @click="atualizarCliente" class="btn btn-primary">Atualizar</button>
    </div>
</template>
<script>
import ClienteDataService from '../../services/ClienteDataService'

export default {
    data() {
        return {
            cliente: {},
            validacoes: {
                nome: false
            }
        }
    },
    methods: {
        atualizarCliente() {
            ClienteDataService.atualizar(this.cliente.id, this.cliente)
                .then(() => {
                    this.$router.push('listar');
                });
        },
        obterCliente(id) {
            ClienteDataService.obterPorId(id)
                .then((response) => {
                    this.cliente = response.data;
                });
        }
    },
    mounted() {
        this.obterCliente(this.$route.params.id);
    }
}

</script>