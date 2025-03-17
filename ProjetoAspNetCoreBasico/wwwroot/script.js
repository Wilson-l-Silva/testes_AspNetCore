async function cadastrarPessoa() {
    const nome = document.getElementById("nome").value;
    const idade = document.getElementById("idade").value;

    if (!nome || !idade) {
        alert("Preencha todos os campos!");
        return;
    }

    const pessoa = { nome, idade: parseInt(idade) };

    try {
        const resposta = await fetch("/api/pessoas", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(pessoa)
        });

        const dados = await resposta.json();
        alert(dados.mensagem);
        listarPessoas();
    } catch (erro) {
        console.error("Erro ao cadastrar pessoa:", erro);
    }
}

async function listarPessoas() {
    try {
        const resposta = await fetch("/api/pessoas");
        const pessoas = await resposta.json();

        let listaHtml = "<ul>";
        pessoas.forEach(pessoa => {
            listaHtml += `<li>${pessoa.nome} - ${pessoa.idade} anos</li>`;
        });
        listaHtml += "</ul>";

        document.getElementById("listaPessoas").innerHTML = listaHtml;
    } catch (erro) {
        console.error("Erro ao buscar pessoas:", erro);
    }
}

            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(pessoa)
        });

        const dados = await resposta.json();
        alert(dados.mensagem);
        listarPessoas();
    } catch (erro) {
        console.error("Erro ao cadastrar pessoa:", erro);
    }
}

async function listarPessoas() {
    try {
        const resposta = await fetch("http://localhost:5147/api/pessoas");
        const pessoas = await resposta.json();

        let listaHtml = "<ul>";
        pessoas.forEach(pessoa => {
            listaHtml += `<li>${pessoa.nome} - ${pessoa.idade} anos</li>`;
        });
        listaHtml += "</ul>";

        document.getElementById("listaPessoas").innerHTML = listaHtml;
    } catch (erro) {
        console.error("Erro ao buscar pessoas:", erro);
    }
}
