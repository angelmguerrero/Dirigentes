<template>
    <div>
        <h1>LogJocabsView</h1>

        <div class="container">
            <v-data-table :headers="headers"
                          :items="desserts"
                          sort-by="idreq"
                          class="elevation-1">
                <template v-slot:top>
                    <v-toolbar flat>
                        <!-- <v-toolbar-title>My CRUD</v-toolbar-title> -->
                        <v-divider class="mx-4" inset vertical></v-divider>
                        <v-spacer></v-spacer>
                        <v-dialog v-model="dialog" max-width="500px">
                            <template v-slot:activator="{ on, attrs }">
                                <v-btn color="primary" dark class="mb-2" v-bind="attrs" v-on="on">
                                    Nuevo Requerimiento
                                </v-btn>
                            </template>
                            <v-card>
                                <v-card-title>
                                    <span class="text-h5">{{ formTitle }}</span>
                                </v-card-title>
                                <v-card-text>
                                    <v-row class="justify-center pa-4">
                                        <v-container>
                                            <v-row>
                                                <v-col cols="12" sm="6">
                                                    <v-text-field v-model="editedItem.idreq"
                                                                  label="Id Requerimiento"
                                                                  disabled></v-text-field>
                                                </v-col>
                                                <v-col cols="12" sm="6">
                                                    <v-file-input counter
                                                                  truncate-length="15"
                                                                  label="Requerimiento"></v-file-input>
                                                </v-col>
                                            </v-row>
                                            <v-row>
                                                <v-col cols="12" sm="6">
                                                    <v-text-field v-model="editedItem.name"
                                                                  label="Nombre"></v-text-field>
                                                </v-col>
                                                <v-col cols="12" sm="6">
                                                    <v-text-field v-model="editedItem.descripcion"
                                                                  label="Descripción"></v-text-field>
                                                </v-col>
                                            </v-row>
                                            <v-row>
                                                <v-col cols="12" sm="6">
                                                    <v-menu ref="menu1"
                                                            v-model="menu1"
                                                            :close-on-content-click="false"
                                                            :return-value.sync="editedItem.fecini"
                                                            transition="scale-transition"
                                                            offset-y
                                                            min-width="auto">
                                                        <template v-slot:activator="{ on, attrs }">
                                                            <v-text-field v-model="editedItem.fecini"
                                                                          label="Fecha "
                                                                          prepend-icon="mdi-calendar"
                                                                          readonly
                                                                          v-bind="attrs"
                                                                          v-on="on"></v-text-field>
                                                        </template>
                                                        <v-date-picker v-model="editedItem.fecini"
                                                                       no-title
                                                                       scrollable>
                                                            <v-spacer></v-spacer>
                                                            <v-btn text color="primary" @click="menu1 = false">
                                                                Cancel
                                                            </v-btn>
                                                            <v-btn text
                                                                   color="primary"
                                                                   @click="$refs.menu1.save(editedItem.fecini)">
                                                                OK
                                                            </v-btn>
                                                        </v-date-picker>
                                                    </v-menu>
                                                </v-col>
                                                <v-spacer></v-spacer>
                                                <v-col cols="12" sm="6">
                                                    <v-menu ref="menu"
                                                            v-model="menu"
                                                            :close-on-content-click="false"
                                                            :return-value.sync="editedItem.fecfin"
                                                            transition="scale-transition"
                                                            offset-y
                                                            min-width="auto">
                                                        <template v-slot:activator="{ on, attrs }">
                                                            <v-text-field v-model="editedItem.fecfin"
                                                                          label="Picker in menu"
                                                                          prepend-icon="mdi-calendar"
                                                                          readonly
                                                                          v-bind="attrs"
                                                                          v-on="on"></v-text-field>
                                                        </template>
                                                        <v-date-picker v-model="editedItem.fecfin"
                                                                       no-title
                                                                       scrollable>
                                                            <v-spacer></v-spacer>
                                                            <v-btn text color="primary" @click="menu = false">
                                                                Cancel
                                                            </v-btn>
                                                            <v-btn text
                                                                   color="primary"
                                                                   @click="$refs.menu.save(editedItem.fecfin)">
                                                                OK
                                                            </v-btn>
                                                        </v-date-picker>
                                                    </v-menu>
                                                </v-col>
                                            </v-row>
                                        </v-container>
                                    </v-row>
                                </v-card-text>

                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn color="blue darken-1" text @click="close">
                                        Cancelar
                                    </v-btn>
                                    <v-btn color="blue darken-1" text @click="save"> Save </v-btn>
                                </v-card-actions>
                            </v-card>
                        </v-dialog>
                        <v-dialog v-model="dialogDelete" max-width="500px">
                            <v-card>
                                <v-card-title class="text-h5">
                                    ¿Estás segura de que quieres eliminar este
                                    artículo?
                                </v-card-title>
                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn color="blue darken-1" text @click="closeDelete">Cancelar</v-btn>
                                    <v-btn color="blue darken-1" text @click="deleteItemConfirm">Sí</v-btn>
                                    <v-spacer></v-spacer>
                                </v-card-actions>
                            </v-card>
                        </v-dialog>
                    </v-toolbar>
                </template>
                <template v-slot:[`item.actions`]="{ item }">
                    <v-icon small class="mr-2" @click="editItem(item)"> mdi-pencil </v-icon>
                    <v-icon small @click="deleteItem(item)"> mdi-delete </v-icon>
                    <v-icon small
                            @click="
            $router.push({
              name: 'DetallereqView',
              params: {
                idreq: item.idreq,
                name: item.name,
                fecini: item.fecini,
              },
            })
          ">mdi-account-details</v-icon>
                </template>
                <template v-slot:no-data>
                    <v-btn color="primary" @click="initialize"> Reset </v-btn>
                </template>
            </v-data-table>
        </div>
    </div>
</template>
<script>





    export default {
        name: 'LogJocabsView',
        components: {




        },








    }</script>