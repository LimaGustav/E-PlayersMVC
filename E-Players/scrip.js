const body = document.getElementById("body")
const burguer = document.querySelector(".burguer")
const nav = document.querySelector(".nav_header")
const isadora = document.querySelector(".box_noticia")
const navLinks = document.querySelectorAll('.nav_header a')


const navSlide = () => {

    //HAMBURGUER MENU
    burguer.addEventListener("click", () => {
        //ANIMAÇÃO HAMBURGUER
        nav.classList.toggle("nav_ativa")

        //ANIMAÇÃO LINKS
        navLinks.forEach((link, index)=> {
            if(link.style.animation){
                link.style.animation = ''
            }
            else {
                link.style.animation = `navHeaderFade 0.5s ease forwards ${index / 7 + 0.4}s`
            }
        })
        // ANIMAÇÃO X DO BURGUER
        burguer.classList.toggle('toggle')


    })
}

const navSome = () => {
    navLinks.forEach((link) => {
        link.addEventListener("click", () => {
            nav.classList.toggle('nav_ativa')
            burguer.classList.toggle('toggle')
            navLinks.forEach((link, index)=> {
                if(link.style.animation){
                    link.style.animation = ''
                }
                else {
                    link.style.animation = `navHeaderFade 0.5s ease forwards ${index / 7 + 0.4}s`
                }
            })
        })
    })
}

navSlide()
navSome()
