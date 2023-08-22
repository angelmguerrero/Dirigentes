<template>
    <div class="sub-footer" v-if="$store.getters['user/getAuthenticated']">
        <div class="footer">
            <b-row class="justify-content-center">
                <div class="social-icons text-center">
                    <br />
                    <ul>
                        <li><a href="#"><i class="fa-brands fa-facebook"></i></a></li>
                        <li><a href="#"><i class="fa-brands fa-twitter"></i></a></li>
                        <li><a href="#"><i class="fa fa-rss"></i></a></li>
                    </ul>
                    <div class="copyright-text">
                        <p> Copyright &copy;  Caja Popular Mexicana 2021</p>
                    </div>
                </div>

            </b-row>

        </div>

    </div>
</template>


<script>
  export default {
    name: 'FooterComp',
  };
</script>
