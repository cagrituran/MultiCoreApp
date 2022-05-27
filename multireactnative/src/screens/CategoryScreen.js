/* eslint-disable prettier/prettier */
/* eslint-disable eol-last */
/* eslint-disable prettier/prettier */
/* eslint-disable react-native/no-inline-styles */
/* eslint-disable prettier/prettier */
/* eslint-disable prettier/prettier */
import React, {Component} from 'react';
import {View,StyleSheet, ActivityIndicator} from 'react-native';
import {DataTable} from 'react-native-paper';
import { Item } from 'react-native-paper/lib/typescript/components/List/List';

export default class CategoryScreen extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoading: false,
      dataSource: [],
    };
  }
  componentDidMount() {
    return fetch('https://multicoreapp-api-fm4.conveyor.cloud/api/Category')
      .then(response => response.json())
      .then(responseJson => {
        this.setState({isLoading: false, dataSource: responseJson});
      })
      .catch(error => console.log('HATA : ' + error));
  }
  render() {
    if (this.state.isLoading) {
      return (
        <View style={{flex: 1, padding: 20}}>
          <ActivityIndicator />
        </View>
      );
    } else {
      return (
        <View style={styles.container}>
          <DataTable>
            <DataTable.Header>
              <DataTable.Title>Id</DataTable.Title>
              <DataTable.Title>Name</DataTable.Title>
              
            </DataTable.Header>
            {this.state.dataSource.map((item,key)=>(
            <DataTable.Row key={item.id}>
              <DataTable.Cell>{item.id}</DataTable.Cell>
              <DataTable.Cell>{item.name}</DataTable.Cell>
              
              
            </DataTable.Row>
    ))}
            
          </DataTable>
        </View>
      );
    }
  }
}
const styles = StyleSheet.create({
  container: {
    paddingTop: 100,
    paddingHorizontal: 30,
  },
});
// export default function CategoryScreen({navigation}) {
//   const {navigate} = navigation;
//   return (
//     <View style={{flex: 1, alignItems: 'center', justifyContent: 'center'}}>
//       <View>
//         <Text>Category Screen</Text>
//       </View>
//     </View>
//   );
// }