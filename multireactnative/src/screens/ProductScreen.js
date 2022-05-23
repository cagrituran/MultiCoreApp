/* eslint-disable prettier/prettier */
import React from 'react'
import {View,Text} from 'react-native';

export default function CategoryScreen({navigation}) {
    const {navigate} = navigation;
  return (
    <View style = {{flex:1,alignItems:'center',justifyContent:'center'}}>
        <View>
          <Text>Product Screen</Text>
        </View>
    </View>
  )
}
