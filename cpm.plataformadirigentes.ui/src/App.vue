<template>
    <div>
        <NavComp />
            <router-view />
        <FooterComp />
    </div>
</template>
<script>
    import NavComp from '@/components/partials/NavComp.vue';
    import FooterComp from '@/components/partials/FooterComp.vue';
    export default {
        name: 'app',
        components: {
    NavComp,
    FooterComp
},
    };
</script>

<style lang="scss">


    @import '~@fortawesome/fontawesome-free/css/all.css';
    @import '~@fortawesome/fontawesome-free/css/brands.css';
    @import '~@fortawesome/fontawesome-free/css/solid.css';
    @import '~@fortawesome/fontawesome-free/css/regular.css';



    @font-face {
        font-family: Montserrat-Regular;
        src: url('assets/fonts/Montserrat/Montserrat-Regular.ttf');
    }

    #app {
        font-family: Montserrat-Regular /*Avenir, Helvetica, Arial, sans-serif*/;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
    }

    bar {
        position: relative;
        background-image: url('@/assets/cpm/banner.jpg')
    }

    nav {
        background-image: url('@/assets/cpm/banner.jpg')
    }

    nav a {
        font-weight: bold;
        color: #42b983;
    }

    nav a.router-link-exact-active {
        color: #42b983;
    }

    .navbar-light .navbar-nav .nav-link {
        color: white;
    }

    .logo {
        display: -webkit-box;
        display: -webkit-flex;
        display: -moz-box;
        display: -ms-flexbox;
        display: flex;
        align-items: center;
        height: 50%;
        margin-right: 55px;
    }

    .logo img {
        max-width: 100%;
        max-height: 100%;
    }

    .limiter-menu-desktop {
        height: 100%;
        display: -webkit-box;
        display: -webkit-flex;
        display: -moz-box;
        display: -ms-flexbox;
        display: flex;
        align-items: center;
        background-color: transparent;
    }

    .img-container {
        width: 126px;
        height: 76px;
        overflow: hidden;
    }

    .img-container img {
        width: 100%;
        height: auto
    }

    body {
        background-color: whitesmoke;
        min-height: 100vh;
    }
    /* Footer Style */
    .footer {
        text-align: center;
        /* align-self: flex-end;
    position: fixed;
    bottom: 0;*/
        width: auto;
        height: 50%;
        background-color: ghostwhite;
    }

    .footer ul {
        padding: 0px;
        margin: 0px;
    }

    .footer ul li {
        list-style: none;
        display: inline-block;
    }

    .footer .logo img {
        max-width: 100%;
        margin-top: 50px;
        margin-bottom: 40px;
    }

    .footer .footer-menu {
        margin-bottom: 40px;
    }

    .footer .footer-menu ul li {
        margin: 0px 15px;
    }

    .footer .footer-menu a {
        font-size: 13px;
        color: #7a7a7a;
        text-transform: uppercase;
        transition: all 0.5s;
    }

    .footer .footer-menu a:hover {
        color: #04B404;
        text-decoration: none;
    }

    .footer .social-icons {
        margin-bottom: 50px;
    }

    .footer .social-icons ul li {
        margin: 0px 10px;
    }

    .footer .social-icons a {
        width: 32px;
        height: 32px;
        color: #fff;
        background-color: #aaa;
        text-align: center;
        display: inline-block;
        line-height: 33px;
        border-radius: 50%;
        font-size: 13px;
        transition: all 0.5s;
    }

    .footer .social-icons a:hover {
        background-color: #04B404;
    }
    /* Sub Footer Style */
    .sub-footer {
        border-top: 1px solid #eee;
        text-align: center;
    }

    .sub-footer p {
        font-size: 12px;
        color: #7a7a7a;
        line-height: 30px;
    }

    .sub-footer a {
        color: #04B404;
        text-decoration: none;
    }
</style>
