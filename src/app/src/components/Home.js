import React, { Component } from 'react';
import {
    StyleSheet,
    ScrollView,
    View,
    Text,
    TextInput,
    Image,
    AsyncStorage,
    ActivityIndicator,
    BackHandler,
    Button,
    TouchableOpacity
} from 'react-native';

import axios from 'axios';

class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
            ready: false,
            Agenda: []
        };
    }

    _confirmaConsulta = async (id) => {
        this.setState({ ready: false });
        
        var token = await AsyncStorage.getItem("@+Care:usuario")
        var self = this;
        await axios.post(`http://192.168.0.135:9591/Api/Agenda/Confirma?agendaId=${id}`, {}, {
            headers: {
                "Content-Type": "application/x-www-form-urlencoded",
                "Authorization": `Bearer ${token}`
            }
        })
            .then(function (response) {
                self.setState({ Agenda: response.data.Agenda })
                // alert(self.state.Agenda[0].Clinica.Nome)
            })
            .catch(function (error) {
                alert(error.message)
            })

        this.setState({ ready: true });
      };

    static navigationOptions = {
        headerTitle: <Text style={{
            fontFamily: 'Raleway Regular',
            fontSize: 20,
            marginLeft: 5,
            color: '#FFFFFF',
            backgroundColor: '#0084C1'
        }}
        >Suas Consultas</Text>
    }

    async componentDidMount() {
        this.setState({ ready: false });

        var token = await AsyncStorage.getItem("@+Care:usuario")
        var self = this;
        await axios.get('http://192.168.0.135:9591/Api/Agenda/GetAgendaPaciente', {
            headers: {
                "Content-Type": "application/x-www-form-urlencoded",
                "Authorization": `Bearer ${token}`
            }
        })
            .then(function (response) {
                self.setState({ Agenda: response.data.Agenda })
                // alert(self.state.Agenda[0].Clinica.Nome)
            })
            .catch(function (error) {
                alert(error.message)
            })

        this.setState({ ready: true });
    }

    render() {
        while (!this.state.ready) {
            return (
                <View style={styles.loadingContainer}>
                    <ActivityIndicator size="large" color="#153566" />
                </View>
            );
        }
        return (
            <ScrollView contentContainerStyle={styles.agendaList}>
                {this.state.Agenda.map(ag =>
                    <View style={styles.agenda}>
                        <View style={styles.agendaInfo}>
                            <Text style={styles.agendaClinica}>{ag.Clinica.Nome}</Text>
                            <Text style={styles.agendaMedico}>{ag.Medico.Nome}</Text>
                            <Text style={styles.agendaEndereco}>{ag.Clinica.Logradouro}, {ag.Clinica.Numero}, {ag.Clinica.Complemento}</Text>
                            <Text style={styles.agendaEndereco}>{Date(ag.DataHoraMarcada)}</Text>

                            {ag.Status == 0 ?
                                (<View style={styles.buttonContainer}>
                                    <TouchableOpacity
                                        style={styles.button}
                                        onPress={() => this._confirmaConsulta(ag.Id)}
                                    >
                                        <Text style={styles.buttonText}>Eu vou!</Text>
                                    </TouchableOpacity>

                                    <TouchableOpacity
                                        style={styles.button}
                                        onPress={() => this.props.onAdd(this.state.newRepoText)}
                                    >
                                        <Text style={styles.buttonText}>Não vou!</Text>
                                    </TouchableOpacity>
                                </View>)
                                :
                                <View style={styles.textoConfirmado}>
                                    <Text style={styles.agendaConfirmado}>Confirmado</Text>
                                </View>
                            }
                        </View>
                    </View>
                )}
            </ScrollView>
        )
    }
}

const styles = StyleSheet.create({
    loadingContainer: {
        flex: 1,
        justifyContent: 'center'
    },
    majorContainer: {
        flex: 1,
        flexDirection: 'row',
        marginBottom: '5%',
        marginTop: '5%',
        marginLeft: '5%',
        marginRight: '5%',
    },
    containerVotacao: {
        flex: 2.5,
        backgroundColor: '#ffffff',
        marginBottom: '6%'
    },
    containerChart: {
        flex: 1.5,
        backgroundColor: '#ffffff'
    },
    defaultFlex: {
        flex: 0,
    },
    textFlex: {
        flex: 0,
        alignItems: 'center'
    },
    text: {
        fontSize: 20,
        color: '#000000'
    },
    circleButtonView: {
        flex: 1,
        width: 40,
        height: 40,
        borderRadius: 40 / 2
    },
    buttonsFlex: {
        flexDirection: 'row',
        flex: 0,
        marginLeft: '10%',
        marginRight: '10%'
    },
    marginContent: {
        marginLeft: '5%',
        marginRight: '5%'
    },

    agendaList: {
        padding: 0
    },

    agenda: {
        padding: 20,
        backgroundColor: '#fff',
        height: 120,
        // marginBottom: 20,
        borderRadius: 5,
        borderBottomColor: '#000',
        borderBottomWidth: 1,
        flexDirection: 'row',
        alignItems: 'center',
        width: '100%',
    },

    agendaInfo: {
        width: '100%',
    },

    agendaClinica: {
        marginLeft: 10,
    },

    agendaClinica: {
        fontSize: 12,
        // fontWeight: 'bold',
        color: '#333'
    },

    agendaMedico: {
        fontSize: 16,
        fontWeight: 'bold',
        color: '#333'
    },

    agendaLogradouro: {
        fontSize: 14,
        color: '#333'
    },

    agendaConfirmado: {
        fontSize: 14,
        color: '#0f0',
        alignItems: 'flex-end',
        fontWeight: 'bold',
    },

    textoConfirmado: {
        height: 20,
        flexDirection: 'row',
        paddingLeft: '75%'
    },

    buttonContainer: {
        height: 20,
        flexDirection: 'row',
        paddingLeft: '60%'
    },

    button: {
        flex: 1,
        alignItems: 'flex-end',
        justifyContent: 'center',
        borderRadius: 3,
    },

    buttonText: {
        fontWeight: 'bold',
        color: '#0084C1',
        fontSize: 14,
    },
});

export default Home;