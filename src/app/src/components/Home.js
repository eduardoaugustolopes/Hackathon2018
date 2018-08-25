import React, { Component } from 'react';
import {
    StyleSheet,
    View,
    Text,
    TextInput,
    Image,
    AsyncStorage,
    ActivityIndicator,
    BackHandler,
    Button
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

    static navigationOptions = {
        headerTitle: <Text style={{
            fontFamily: 'Raleway Regular',
            fontSize: 20,
            marginLeft: 5,
            color: '#FFFFFF'
        }}
        >Suas Cosultas</Text>
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
                alert(self.state.Agenda[0].Clinica.Nome)
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
            <View style={styles.majorContainer}>
                {this.state.Agenda.map(index => {
                    <View>
                        <Text style={styles.text}>{index.Clinica.Nome}</Text>
                    </View>
                })}
            </View>
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
        flexDirection: 'column',
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
    }
});

export default Home;