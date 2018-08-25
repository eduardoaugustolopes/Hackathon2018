import React from 'react';
import { StackNavigator, DrawerNavigator } from 'react-navigation';
import { Image, Animated, Easing, Text, StyleSheet, View, ImageBackground, TouchableOpacity } from 'react-native';

import Login from './components/Login';
import Home from './components/Home';
import Cofiguracao from './components/Configuracao';

const noTransitionConfig = () => ({
    transitionSpec: {
        duration: 0,
        timing: Animated.timing,
        easing: Easing.step0
    }
})

const DrawerStack = DrawerNavigator({
    Home: { screen: Home },
    Cofiguracao: { screen: Cofiguracao }
},
    {
        drawerOpenRoute: 'DrawerOpen',
        drawerCloseRoute: 'DrawerClose',
        drawerToggleRoute: 'DrawerToggle',
        contentComponent: (props) => (
            <View style={{ position: 'absolute' }}>
                <ImageBackground style={styles.imageBackground} source={require('./img/banner.png')}>
                    <View style={styles.imageContentSideDrawer}>
                        <Image
                            style={styles.image}
                            source={require('./img/100melhores-instituicao.png')}
                        />
                    </View>
                    <View style={styles.textContentSideDrawer}>
                        <Text style={styles.userName}>Nome do usuário</Text>
                        <Text style={styles.userPhone}>(037) 99999-9999</Text>
                    </View>
                </ImageBackground>
                <View sytle={styles.sidedrawerFirstOptions}>
                    <TouchableOpacity><Text onPress={() => props.navigation.navigate('Configuração')} style={styles.sidedrawerOption}>Conficuração</Text></TouchableOpacity>
                    <TouchableOpacity>
                        <Text onPress={async () => {
                            props.navigation.navigate('loginScreen');
                        }} style={styles.sidedrawerOption}>Sair</Text>
                    </TouchableOpacity>
                </View>
            </View>
        )
    }
);

const DrawerNavigation = StackNavigator({
    DrawerStack: {
        screen: DrawerStack,
        navigationOptions: ({ navigation }) => ({
            headerLeft: buttonHeader(navigation),
        }),
    },
},
    {
        headerMode: 'float',
        transitionConfig: noTransitionConfig,
        navigationOptions: {
            headerStyle: { backgroundColor: '#00193b' }
        }
    }
);

const buttonHeader = (navigation) =>
    <TouchableOpacity onPress={async () => {
        if (navigation.state.index === 0) {
            await navigation.navigate('DrawerOpen');
        } else {
            await navigation.navigate('DrawerClose');
        }
    }}>
        <Image
            source={{ uri: 'https://somosnoticia.com.br/wp-content/themes/giornalismo/images/mobile-nav-icon.png' }}
            style={{ width: 26, height: 18, marginLeft: 15 }}
        />
    </TouchableOpacity>



const LoginStack = StackNavigator({
    loginScreen: { screen: Login },
},
    {
        headerMode: 'none',
        transitionConfig: noTransitionConfig
    }
);

const PrimaryNav = StackNavigator({
    loginStack: { screen: LoginStack },
    drawerStack: { screen: DrawerNavigation },
},
    {
        headerMode: 'none',
        transitionConfig: noTransitionConfig
    }
);

export default PrimaryNav;

const styles = StyleSheet.create({
    headerTitle: {
        fontFamily: 'Raleway Regular',
        fontSize: 20,
        marginLeft: 5,
        color: '#FFFFFF'
    },
    imageBackground: {
        width: '200%',
    },
    image: {
        width: 88,
        height: 100,
    },
    imageContentSideDrawer: {
        marginTop: '4%',
        paddingLeft: '11%',
    },
    userName: {
        color: '#ffffff',
        fontSize: 18,
        fontWeight: 'bold',
    },
    userPhone: {
        color: '#ffffff',
        fontSize: 15,
    },
    textContentSideDrawer: {
        marginTop: 20,
        justifyContent: 'center',
        marginBottom: 10,
        marginLeft: '10%',
    },
    container: {
        flex: 1,
        backgroundColor: '#f6f6f6',
        paddingTop: 20,
        paddingHorizontal: 20
    },
    sidedrawerOptions: {
        alignItems: 'center',
        justifyContent: 'space-between',
    },
    sidedrawerOption: {
        marginTop: 15,
        color: '#023D44',
        fontSize: 20,
        marginLeft: 60,
    },
    sidedrawerDiferentOption: {
        marginTop: 50,
        color: '#023D44',
        fontSize: 20,
        marginLeft: 60,
    }
});
