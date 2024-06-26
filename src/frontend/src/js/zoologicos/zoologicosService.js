$(document).ready(function() {
    listarZoologicos()
})

function listarZoologicos() {
    const url = 'https://localhost:44376/zoologicos/GetAll'

    fetch(url)
    .then(response => response.json())
    .then(response => {
        if(response.success){
            

            const container = document.getElementById('rowContainer')
            
            response.data.forEach(zoo => {
                const card = document.createElement("div")
                card.classList.add("col-xl-4", "col-lg-4", "col-md-6", "col-sm-12", "col-xs-12", "my-2");
                card.innerHTML = `
                    <div class="col-xl-4 col-lg-4 col-md-6 col-sm-12 col-xs-12 my-2">
                        <div class="card text-center" style="width: 18rem; height: 20rem">
                            <img src="images/zoologico.jpg" class="" alt="...">
                        <div class="card-body">
                            <h5 class="card-title">${zoo.nombre}</h5>
                            <p class="card-text">${zoo.especie.nombreVulgar}.</p>
                            <a href="#" class="btn btn-primary">Go somewhere</a>
                        </div>
                        </div>
                    </div>
                `

                container.append(card);
            });
        } else{
            console.log(response.errorMessage)
        }
    })
    .catch(error => {
        console.log(error)
    })

}