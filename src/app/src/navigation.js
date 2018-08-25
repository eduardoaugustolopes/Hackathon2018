import React from 'react';
import { StackNavigator, DrawerNavigator } from 'react-navigation';
import { Image, Animated, Easing, Text, StyleSheet, View, ImageBackground, TouchableOpacity, AsyncStorage } from 'react-native';

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
            <View style={styles.container}>
                <View style={styles.textContentSideDrawer}>
                    <View style={styles.mainImageContentSideDrawer}>
                        <Image
                            style={styles.image}
                            source={require('./img/icone_user.png')}
                        />
                    </View>
                    <View style={styles.textFlex}><Text style={styles.text}>Nome do usuário</Text></View>
                </View>
                <View style={styles.line}></View>
                <View style={styles.defaultFlex}>
                    <View style={styles.flexOptions}>
                        {/* <View style={styles.imageContentSideDrawer}> */}
                            <Image
                                style={styles.icons}
                                source={require('./img/icone_engrenagem.png')}
                            />
                        {/* </View> */}
                        <TouchableOpacity style={styles.imageContentSideDrawer}>
                            <Text onPress={() => props.navigation.navigate('Configuracao')} style={styles.sidedrawerOption}>Configuração</Text>
                        </TouchableOpacity>
                    </View>
                    <View style={styles.flexOptions}>
                        {/* <View style={styles.imageContentSideDrawer}> */}
                            <Image
                                style={styles.icons}
                                source={require('./img/icone_sair.png')}
                            />
                        {/* </View> */}
                        <TouchableOpacity style={styles.imageContentSideDrawer}>
                            <Text onPress={async () => {
                                await AsyncStorage.removeItem("@+Care:usuario");
                                props.navigation.navigate('loginScreen');
                            }} style={styles.sidedrawerOption}>Sair</Text>
                        </TouchableOpacity>
                    </View>
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
            headerStyle: { backgroundColor: '#0084C1' }
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
    imageBackground: {
        width: '200%',
    },
    image: {
        width: 50,
        height: 50
    },
    mainImageContentSideDrawer: {
        flex: 1,
    },
    imageContentSideDrawer: {
        flex: 1,
    },
    buttonFlex: {
        flex: 3,
    },
    text: {
        color: '#000000',
        fontSize: 20,
        fontWeight: 'bold',
    },
    textFlex: {
        flex: 3
    },
    textContentSideDrawer: {
        flexDirection: 'row',
        flex: 0.2,
        marginLeft: '2%',
        alignItems: 'center',
        justifyContent: 'center'
    },
    container: {
        flex: 0.25,
        backgroundColor: '#ffffff',
        paddingTop: '10%',
    },
    sidedrawerOption: {
        marginTop: '2%',
        color: '#023D44',
        fontSize: 18,
        marginLeft: 8,
        // flex: 1
    },
    line: {
        borderBottomColor: '#000000',
        borderBottomWidth: 1,
        flex: 1
    },
    flexOptions: {
        flexDirection: 'row',
        height: 40,
        // flex: 2,
    },
    icons: {
        width: 25,
        height: 25,
        marginLeft: 10,
        marginTop: 10,
    },
    defaultFlex: {
        flex: 1
    },
});
