/* eslint-disable prettier/prettier */
/* eslint-disable react-native/no-inline-styles */
/* eslint-disable prettier/prettier */
import React from 'react';
import {View, Text} from 'react-native';
import {NavigationContainer} from '@react-navigation/native';
import {createNativeStackNavigator} from '@react-navigation/native-stack';
import HomeScreen from './screens/HomeScreen';
import CategoryScreen from './screens/CategoryScreen';
import ProductScreen from './screens/ProductScreen';

const Stack = createNativeStackNavigator();

export default function Router() {
  return (
    <NavigationContainer>
      <Stack.Navigator initialRouteName="Home">
        <Stack.Screen
          name="Home"
          component={HomeScreen}
          options={{
            title: 'MyHome',
            headerTitle: () => (
              <Text style={{fontWeight: 'bold'}}>Multi Core App</Text>
            ),
          }}
        />
        <Stack.Screen
          name="Category"
          component={CategoryScreen}
          options={{
            title: 'Categories',
            headerTitle: () => (
              <Text style={{fontWeight: 'bold'}}>Category</Text>
            ),
          }}
        />
        <Stack.Screen
          name="Product"
          component={ProductScreen}
          options={{
            title: 'Products',
            headerTitle: () => (
              <Text style={{fontWeight: 'bold'}}>Products</Text>
            ),
          }}
        />
      </Stack.Navigator>
    </NavigationContainer>
  );
}
