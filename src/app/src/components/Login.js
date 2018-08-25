import React, { Component } from 'react';
import {
    StyleSheet,
    View,
    Text,
    TextInput,
    Image,
    ActivityIndicator,
    Button,
    ImageBackground,
    AsyncStorage
} from 'react-native';

import api from '../api';

import TextInputMask from 'react-native-text-input-mask';

import querystring from 'query-string';

class Login extends Component {

    constructor(props) {
        super(props);
        this.state = {
            cpf: '',
            ready: null,
            senha: '',
            message: '',
        };
    }

    handleEntrarPress = async () => {
        if (!this.state.cpf || !this.state.senha) {
            this.setModalVisible(true);
        } else {
            let self = this;
            await api.post('security/token', querystring.stringify({
                username: this.state.cpf,
                password: this.state.senha,
                grant_type: 'password'
            }),
                {
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                })
                .then(async function (response) {
                    await AsyncStorage.setItem("@+Care:usuario", response.data.access_token)
                    self.props.navigation.navigate('drawerStack');
                })
                .catch(function (e) {
                    self.setState({ message: e.response.data.message })
                    alert(self.state.message);
                })
        }
    };

    handleForgotPress = () => {
        // this.props.navigation.navigate('EnviaSMS');
    };

    handleCadastrarButton = () => {
        // this.props.navigation.navigate('Cadastro');
    }

    async componentDidMount() {
        this.setState({ ready: false });

        var token = await AsyncStorage.getItem("@+Care:usuario");

        if (token) {
            this.props.navigation.navigate('drawerStack');
        }

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
            <View style={styles.containerFlex}>
                <View style={styles.imageContainer}>
                    <Image
                        style={styles.image}
                        source={require('../img/+Care_Logo_Mobile.png')}
                    />
                </View>
                <View style={styles.textInputFlex}>
                    <TextInputMask
                        refInput={ref => { this.input = ref }}
                        style={styles.textInput}
                        placeholder="CPF"
                        keyboardType="numeric"
                        placeholderTextColor="#606062"
                        underlineColorAndroid="transparent"
                        onChangeText={(formatted, extracted) => {
                            this.setState({ cpf: extracted })
                        }}
                        mask={"[000].[000].[000]-[00]"}
                    />
                </View>
                <View style={styles.textInputFlex}>
                    <TextInput
                        style={styles.textInput}
                        secureTextEntry={true}
                        placeholder="Senha"
                        placeholderTextColor="#606062"
                        underlineColorAndroid="transparent"
                        onChangeText={(text) => this.setState({ senha: text })}
                    />
                </View>
                <View style={styles.buttonFlex}>
                    <Button
                        color="#6ddfe4"
                        onPress={this.handleEntrarPress}
                        title="Log in"
                    />
                </View>
                <View style={styles.footerTextFlex}>
                    <Text style={styles.textFooter}>Cadastre-se</Text>
                    <Text style={styles.textFooter}>Esqueci minha senha</Text>
                </View>
            </View>
        );
    }
}

const styles = StyleSheet.create({
    containerFlex: {
        flex: 1,
        backgroundColor: '#0084c1'
    },
    imageContainer: {
        marginTop: '10%',
        alignItems: 'center',
        flex: 0.8,
    },
    imageBackground: {
        width: '100%',
        alignItems: 'center',
        justifyContent: 'center',
        height: '100%'
    },
    image: {
        width: 283,
        height: 200
    },
    textInput: {
        fontSize: 22,
        color: '#606062',
        borderColor: '#ffffff',
        backgroundColor: '#ffffff',
        borderRadius: 10,
        borderWidth: 1,
    },
    text: {
        fontSize: 28,
        fontWeight: 'bold',
        color: '#024684'
    },
    textForgot: {
        fontSize: 14,
        color: '#2977FF'
    },
    loadingContainer: {
        flex: 1,
        justifyContent: 'center'
    },
    defaultFlex: {
        flex: 0,
    },
    textInputFlex: {
        flex: 0.3,
        marginLeft: '6%',
        marginRight: '6%',
    },
    buttonFlex: {
        flex: 0.3,
        marginLeft: '6%',
        marginRight: '6%',
    },
    imageFooter: {
        width: 120,
        height: 34
    },
    imageFooterFlex: {
        marginTop: '3%',
        alignItems: 'center',
    },
    footerTextFlex: {
        flex: 0.2,
        alignItems: 'center',
        flexDirection: 'row',
        marginLeft: '6%',
        marginRight: '6%',
    },
    textFooter: {
        flex: 1,
        fontSize: 16,
        color: '#ffffff',
    },
});

export default Login;