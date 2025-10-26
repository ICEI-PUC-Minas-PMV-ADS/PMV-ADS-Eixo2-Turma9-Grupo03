const API_URL = "http://localhost:5297/api/lembretes";

// alternar abas
function abrirAba(nome) {
  document.querySelectorAll(".aba").forEach(sec => sec.classList.remove("ativa"));
  document.getElementById(nome).classList.add("ativa");
}

// alternar menu
function toggleMenu() {
  document.getElementById("menu").classList.toggle("ativo");
}

// carregar lembretes
async function carregarLembretes() {
  const resposta = await fetch(API_URL);
  const lembretes = await resposta.json();
  const lista = document.getElementById("listaLembretes");

  lista.innerHTML = "";
  lembretes.forEach(l => {
    const card = document.createElement("div");
    card.classList.add("lembrete-card");

    card.innerHTML = `
      <div>
        <strong>${l.titulo}</strong><br/>
        <small>${l.dias} — ${l.intervaloHoras}h</small>
      </div>
      <button onclick="excluirLembrete(${l.id})">Remover</button>
    `;

    lista.appendChild(card);
  });
}

// adicionar lembrete
document.getElementById("formLembrete").addEventListener("submit", async e => {
  e.preventDefault();

  const titulo = document.getElementById("titulo").value;
  const dias = document.getElementById("dias").value;
  const intervaloHoras = parseInt(document.getElementById("intervalo").value);

  if (!titulo || !dias || !intervaloHoras) return;

  await fetch(API_URL, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ id: 0, titulo, dias, intervaloHoras })
  });

  e.target.reset();
  carregarLembretes();
});

// excluir lembrete
async function excluirLembrete(id) {
  await fetch(`${API_URL}/${id}`, { method: "DELETE" });
  carregarLembretes();
}

// inicializar
carregarLembretes();